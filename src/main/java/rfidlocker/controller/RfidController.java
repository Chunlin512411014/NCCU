package rfidlocker.controller;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.servlet.ModelAndView;

import jakarta.servlet.http.HttpServletRequest;


@CrossOrigin
@Controller
public class RfidController {
	 final String pass_token = "12344444"; 
	 final String pass_cardNo = "3698607872"; 
	 
	 
	@GetMapping(value ="/card/{cardNo}" )
	public ResponseEntity<String> getData(@PathVariable String cardNo
			,HttpServletRequest request ) {
		
		 try {
			 String access ="N";
				System.out.println(cardNo);
				String userAgent = request.getHeader("Authorization");
				System.out.println("token : "+ userAgent);
				String token = userAgent.substring(7);
				System.out.println(token);
				
				if(!pass_token.equals(token)) {
					return new ResponseEntity<>("N", HttpStatus.FORBIDDEN);
				}
				
				if(pass_cardNo.equals(cardNo) ) {
					return new ResponseEntity<>("Y", HttpStatus.OK);
				}
				
				ModelAndView mv ;
				return new ResponseEntity<>("N", HttpStatus.FORBIDDEN);
			 
			 
		 }catch (Exception e ) {
			 e.printStackTrace();
			 return new ResponseEntity<>("N", HttpStatus.FORBIDDEN);
		 }
		
		
	}

}
