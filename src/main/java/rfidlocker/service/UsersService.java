package rfidlocker.service;

import rfidlocker.entity.Users;

public interface UsersService {
	Users getUserByEmail(String email);
}
