package rfidlocker.service;

import rfidlocker.entity.Users;
/*
 * Users Service interface
 * 用於商業邏輯應用
 * */
public interface UsersService {
	Users getUserByEmail(String email);
}
