package rfidlocker.service;

import java.util.List;

import rfidlocker.entity.Boxes;

public interface BoxesService {
	
	List<Boxes> getAllBoxes();
	List<Boxes> getAllBoxesByloaction(String location);
	Boxes getBoxesById(Integer boxId);
	Boxes addBoxes(String name , String location );
	Boxes modifyBoxes(Integer boxId,String name, String location , String status);
	void modifyBoxesDoorStatus(Integer boxId , String isLock);
}
