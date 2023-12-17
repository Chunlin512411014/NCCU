package rfidlocker.service.impl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import lombok.extern.slf4j.Slf4j;
import rfidlocker.entity.Boxes;
import rfidlocker.repository.BoxesJpaRepository;
import rfidlocker.service.BoxesService;

@Slf4j
@Service
public class BoxesServiceImpl implements BoxesService {

	@Autowired
	BoxesJpaRepository boxesJpaRepository;

	@Override
	public List<Boxes> getAllBoxes() {

		List<Boxes> boxesList = boxesJpaRepository.findAll();

		return boxesList;
	}

	@Override
	public Boxes getBoxesById(Integer boxId) {
		return boxesJpaRepository.findById(boxId).get();
	}

	@Override
	public Boxes addBoxes(String name, String location) {
		Boxes boxes = boxesJpaRepository.findByName(name).orElse(null);
		if (boxes != null) {
			throw new IllegalStateException("box名稱已存在");
		}
		boxes = new Boxes();
		boxes.setName(name);
		boxes.setLocation(location);
		boxes.setStatus("A");
		boxes = boxesJpaRepository.save(boxes);
		return boxes;
	}

	@Override
	public Boxes modifyBoxes(Integer boxId, String name, String location, String status) {
		Boxes boxes = boxesJpaRepository.findById(boxId).orElseThrow(()->new IllegalStateException("box不存在"));
		
		if (name != null && boxesJpaRepository.findByName(name).isPresent()) {
			throw new IllegalStateException("box名稱已存在");
		}
		
		boxes.setName(name);
		boxes.setLocation(location);
		boxes.setStatus("A");
		boxes = boxesJpaRepository.save(boxes);
		return boxes;
	}

	@Override
	public void modifyBoxesDoorStatus(Integer boxNo, String isLock) {
		Boxes boxes = boxesJpaRepository.findByBoxNo(boxNo).orElseThrow(()->new IllegalStateException("box不存在"));
		if("Y".equals(isLock)) {
			boxes.setIsLock(true);
		}else {
			boxes.setIsLock(false);
		}
		boxesJpaRepository.save(boxes);
		log.info("box : "+boxes.getName()+"是否上鎖 : "+boxes.getIsLock());
	}

}
