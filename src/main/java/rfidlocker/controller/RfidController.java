package rfidlocker.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.servlet.ModelAndView;

import jakarta.servlet.http.HttpServletRequest;
import lombok.extern.slf4j.Slf4j;
import rfidlocker.service.BoxesService;
import rfidlocker.service.RfidService;

@CrossOrigin
@Controller
@Slf4j
public class RfidController {

	@Autowired
	BoxesService boxesService;
	@Autowired
	RfidService rfidService;

	final String pass_token = "12344444";
	final String pass_cardNo = "3698607872";

	//測試API
	@GetMapping(value = "/card/{cardNo}")
	public ResponseEntity<String> getData(@PathVariable String cardNo, HttpServletRequest request) {

		try {
			String access = "N";
			System.out.println(cardNo);
			String userAgent = request.getHeader("Authorization");
			System.out.println("token : " + userAgent);
			String token = userAgent.substring(7);
			System.out.println(token);

			if (!pass_token.equals(token)) {
				return new ResponseEntity<>("N", HttpStatus.FORBIDDEN);
			}

			if (pass_cardNo.equals(cardNo)) {
				return new ResponseEntity<>("Y", HttpStatus.OK);
			}

			ModelAndView mv;
			return new ResponseEntity<>("N", HttpStatus.FORBIDDEN);

		} catch (Exception e) {
			e.printStackTrace();
			return new ResponseEntity<>("N", HttpStatus.FORBIDDEN);
		}

	}

	/*
	 * rfid 辨識 parameter 1. cardNo 2.boxId
	 * 判斷此卡是否有效
	 */

	@GetMapping(value = "/rfid/{cardNo}/{boxId}")
	public ResponseEntity<String> checkCardNoAndBoxId(@PathVariable String cardNo, 
			@PathVariable Integer boxId,
			HttpServletRequest request) {
		
		try {
		String access = rfidService.checkCardNOAndBoxId(cardNo, boxId);
		return new ResponseEntity<>(access, HttpStatus.OK);
		} catch (Exception e) {
			e.printStackTrace();
			return new ResponseEntity<>("N", HttpStatus.FORBIDDEN);
		}

	}
	/*
	 * 門鎖感應器 現在是開或是關
	 * 
	 * */
	@GetMapping(value = "/rfid/door/{boxId}/{isLock}")
	public ResponseEntity<?> updateBoxesDoorStatus(@PathVariable Integer boxId,
			@PathVariable String isLock,
			HttpServletRequest request) {
		try {
			boxesService.modifyBoxesDoorStatus(boxId, isLock);
//			return new ResponseEntity<>(access, HttpStatus.OK);
			System.out.println("isLock :" +isLock);
		} catch (Exception e) {
//			return new ResponseEntity<>("N", HttpStatus.FORBIDDEN);
			System.out.println();
			e.printStackTrace();
			log.info("boxes door status error");
		}
		return new ResponseEntity<>(HttpStatus.OK);


	}

}
