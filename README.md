
  <h3 align="center">Remote Sensor Locker</h3>

---

<!-- ABOUT THE PROJECT -->
## About The Project

此專案為了解決現在個人面交取貨問題，有些物品可能不適合運送，或是距離過近想節省運費，為了不讓交易雙方為了交易，必須安排彼此都可以的時間之外，疫情間也可以避開人與人的接觸，該專案透過 Web Applicaiton 結合 RFID Sensor Locker, 讓交易過程更自由，更能保持商品完整性。 

### Built With

- #### Infra
  - ##### Docker
  - ##### MySQL
  - ##### GCP (Options)

- #### Frontend & Backend
  - ##### Java Sprint Boot (MVC Architecture)

---

<!-- GETTING STARTED -->
## Getting Started

以下是設置專案本地環境的簡單步驟，請按照這些步驟操作以啟動本地副本。

### Prerequisites

- #### OS requirements
  - ##### Ubuntu 18.04 or above
  - ##### Mac OS 10.15 or above
  - ##### Windows 10 or above

---

### Installation

- #### Install Docker Engine on Ubuntu
  - apt update
   ```sh
   sudo apt-get update
   ```
  - Install certificates and curl gnupg
   ```sh
   sudo apt-get install ca-certificates curl gnupg
   ```
   
     - Add Docker's official GPG key
   ```sh
   sudo install -m 0755 -d /etc/apt/keyrings
   ```
   ```sh
   curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /etc/apt/keyrings/docker.gpg
   ```
   ```sh
   sudo chmod a+r /etc/apt/keyrings/docker.gpg
   ```
   ```sh
   echo \
   "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.gpg] https://download.docker.com/linux/ubuntu \
   $(. /etc/os-release && echo "$VERSION_CODENAME") stable" | \
   sudo tee /etc/apt/sources.list.d/docker.list > /dev/null
   ```
   ```sh
   sudo apt-get update
   ```
   - To install the latest version
   ```sh
   sudo apt-get install docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin
   ```
   - Verify that the Docker Engine installation is successful.
   ```sh
   sudo docker run hello-world
   ```

- #### Install Docker Desktop on Mac
  - Install from command line
  ```sh
  sudo hdiutil attach Docker.dmg
  sudo /Volumes/Docker/Docker.app/Contents/MacOS/install
  sudo hdiutil detach /Volumes/Docker
  ```
  - Verify that the Docker Engine installation is successful.
  ```sh
  sudo docker run hello-world
  ```

---


- Starting a MySQL instance
```sh
docker run -itd --name mysql -p 3306:3306 -e MYSQL_ROOT_PASSWORD=123456 mysql
```

---

- Options
   - Maven
   - OpenJDK

---


<!-- USAGE EXAMPLES -->
## Usage


<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.