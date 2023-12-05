package rfidlocker.service.impl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import rfidlocker.entity.Users;
import rfidlocker.repository.UsersJpaRepository;
import rfidlocker.service.UsersService;
@Service
public class UsersServiceImpl implements UsersService{
	@Autowired
	UsersJpaRepository usersJpaRepository;
	@Override
	public Users getUserByEmail(String email) {
		Users users = usersJpaRepository.findByEmail(email).orElse(null);
		if(users == null) return users;
		Users userDao = new Users();
		userDao.setEmail(users.getEmail());
		userDao.setName(users.getName());
		userDao.setId(users.getId());
		return userDao;
	}

	
}
