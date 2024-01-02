package rfidlocker.service;
/*
 * ＲFID Service interface
 * 用於商業邏輯應用
 * */
public interface RfidService {
	
	String checkCardNOAndBoxId(String cardNo, Integer boxId);
}
