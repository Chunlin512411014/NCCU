#include <WiFi.h>
#include <SPI.h>
#include <MFRC522.h>
#include <HTTPClient.h>
#define LED_PIN  2  // ESP32 pin GPIO2 
#define SS_PIN  5  // ESP32 pin GPIO5 
#define RST_PIN 27 // ESP32 pin GPIO27 
#define LOCK_PIN 13 // Lock pin GPIO13
#define RED_PIN 12

MFRC522 rfid(SS_PIN, RST_PIN);
const char* ssid     = "hitron-c390"; // Change this to your WiFi SSID
const char* password = "0983244167"; // Change this to your WiFi password
//const char* lineToken = "8YQU8PwESls71OnOK6RTPt5OjvkVtMxN44iZw2ECvxl";//Line Token 美
const char* lineToken = "Mtl34bAjplX1eXm7FU7VdswuNvdsAApL3FgXQPZz0ps";//Line Token 櫃付


const char* host = "api.thingspeak.com"; // This should not be changed
const int httpPort = 80; // This should not be changed
const String channelID   = "2005329"; // Change this to your channel ID
const String writeApiKey = "V6YOTILH9I7D51F9"; // Change this to your Write API key
const String readApiKey = "34W6LGLIFXD56MPM"; // Change this to your Read API key
TaskHandle_t Task1;


// The default example accepts one data filed named "field1"
// For your own server you can ofcourse create more of them.
int field1 = 0;
bool showBlink = false;

void setup()
{
    Serial.begin(115200);
    pinMode(LED_BUILTIN, OUTPUT);
    pinMode(LOCK_PIN,OUTPUT);
    pinMode(RED_PIN,OUTPUT);
    
    
    while(!Serial){delay(100);}

    //1. connect wifi
    connectWifi();

    //2. check lock/ gpio
    digitalWrite(LOCK_PIN,HIGH);
    delay(1000);
    digitalWrite(LOCK_PIN,LOW);
    delay(1000);
    digitalWrite(LOCK_PIN,HIGH);
    delay(1000);
    digitalWrite(LOCK_PIN,LOW);

    //3. init RC522
    SPI.begin(); // init SPI bus
    rfid.PCD_Init(); // init MFRC522
    Serial.println("Tap an RFID/NFC tag on the RFID-RC522 reader");
}
void blinkLED(){
  showBlink = true;
  do {
    digitalWrite(LED_BUILTIN,HIGH);
    delay(100);
    digitalWrite(LED_BUILTIN,LOW);
    delay(100);
  } while (showBlink == true); 
}
void loop(){
  if ( ! rfid.PICC_IsNewCardPresent())// Look for new cards
    return;

  if ( ! rfid.PICC_ReadCardSerial())// Verify if the NUID has been readed
    return;
  
  //int code = Task1_sendWebApi(readcard());
  int code = sendWebApi(readcard());
  showBlink = false;
  Serial.println(code);
  if(code == 200){
    openLock();
  }else{
    digitalWrite(RED_PIN,HIGH);
    delay(400);
    digitalWrite(RED_PIN,LOW);
    delay(300);
    digitalWrite(RED_PIN,HIGH);
    delay(400);
    digitalWrite(RED_PIN,LOW);
    delay(300);
  }
  Serial.println("Tap an RFID/NFC tag on the RFID-RC522 reader");
  //sendWebApi();
}
void connectWifi(){
    // 1. We start by connecting to a WiFi network
    Serial.println();
    Serial.println("******************************************************");
    Serial.print("Connecting to ");
    Serial.println(ssid);
    WiFi.disconnect();
    WiFi.begin(ssid, password);
    WiFi.hostname("Esp32");

    while (WiFi.status() != WL_CONNECTED) {
        digitalWrite(LED_PIN,HIGH);
        delay(250);
        digitalWrite(LED_PIN,LOW);
        delay(250);
        Serial.print(".");
    }

    Serial.println("");
    Serial.println("WiFi connected");
    Serial.println("IP address: " + WiFi.localIP());
}
int Task1_sendWebApi(String cardNo) {
    Serial.println("send web api with card no :" + cardNo);
    HTTPClient http;

    http.begin("https://notify-api.line.me/api/notify");
    http.addHeader("Authorization", "Bearer " + String(lineToken));
    http.addHeader("Content-Type", "application/x-www-form-urlencoded");

    String message = "message=歐逆醬早安!!!"+ cardNo +"&stickerPackageId=2&stickerId=523" ;
    int httpResponseCode = http.POST(message);

    if (httpResponseCode > 0) {
      String response = http.getString();
      Serial.println(httpResponseCode);
      Serial.println(response);
    } else {
      Serial.println("Error on sending POST request");
    }

    http.end();
    delay(500); // wait
    
    if(cardNo !="3698607872"){
      return 403; //Forbidden
    }
    return httpResponseCode;
}
int sendWebApi(String cardNo) {
    Serial.println("send web api with card no :" + cardNo);
    HTTPClient http;

    http.begin("http://192.168.0.25:18080/" + cardNo);
    http.addHeader("Authorization", "Bearer 12344444");
    http.addHeader("Content-Type", "application/x-www-form-urlencoded");

    
    int httpResponseCode = http.GET();

    if (httpResponseCode > 0) {
      String response = http.getString();
      Serial.println(httpResponseCode);
      Serial.println(response);
    } else {
      Serial.println("Error in HTTP request");
      Serial.println("HTTP Error: " + http.errorToString(httpResponseCode));
    }

    http.end();
    delay(500); // wait
    

    return httpResponseCode;
}


void openLock(){
  Serial.println("openLock");
  digitalWrite(LOCK_PIN,HIGH);
  digitalWrite(LED_BUILTIN,HIGH);

  //delay(1000);
  //digitalWrite(LOCK_PIN,LOW);
  //digitalWrite(LED_BUILTIN,LOW);
  delay(1000);
}

void closeLock(){
  Serial.println("closeLock");
  digitalWrite(LOCK_PIN,LOW);
  digitalWrite(LED_BUILTIN,LOW);

  //delay(1000);
  //digitalWrite(LOCK_PIN,LOW);
  //digitalWrite(LED_BUILTIN,LOW);
  delay(1000);
}
void readResponse(WiFiClient *client){
  unsigned long timeout = millis();
  while(client->available() == 0){
    if(millis() - timeout > 5000){
      Serial.println(">>> Client Timeout !");
      client->stop();
      return;
    }
  }

  // Read all the lines of the reply from server and print them to Serial
  while(client->available()) {
    String line = client->readStringUntil('\r');
    Serial.print(line);
  }

  Serial.printf("\nClosing connection\n\n");
}



//-------------------------




String readcard() {
  if (rfid.PICC_IsNewCardPresent()) { // new tag is available
    if (rfid.PICC_ReadCardSerial()) { // NUID has been readed
      MFRC522::PICC_Type piccType = rfid.PICC_GetType(rfid.uid.sak);
      Serial.print("RFID/NFC Tag Type: ");
      Serial.println(rfid.PICC_GetTypeName(piccType));

      // print UID in Serial Monitor in the hex format
      Serial.print("UID:");
      for (int i = 0; i < rfid.uid.size; i++) {
        Serial.print(rfid.uid.uidByte[i] < 0x10 ? " 0" : " ");
        Serial.print(rfid.uid.uidByte[i], HEX);
      }
      Serial.println();
      //取得卡號
      String CardNo = getCardNo(rfid.uid.uidByte, rfid.uid.size);
      Serial.print("detected cardno = ");
      Serial.println(CardNo);
      

      rfid.PICC_HaltA(); // halt PICC
      rfid.PCD_StopCrypto1(); // stop encryption on PCD
      return CardNo;
    }
  }
}

String getCardNo(byte *buffer, byte bufferSize){
 String inStringHexRev="";
 String Final ="";
  for (byte i = 0; i < bufferSize; i++) {
    String tmp = String(buffer[bufferSize-(i+1)], HEX);
     if(tmp.length()==1){
      tmp= "0" + tmp;
    }
    inStringHexRev += tmp;
  }
  long unsigned B = strtoul(inStringHexRev.c_str(),NULL,16);
  Final = String(B);
  while(Final.length()<10){
    Final="0"+Final;
  }
  return Final;
}
