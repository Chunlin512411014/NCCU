package rfidlocker.utils;


public class CheckUtil {
	
	public static boolean checkRole () {
		String role = (String) SessionUtil.getSession().getAttribute("role");
    	if (role == null || role == "") {
    		return false;
    	}
    	return true;
	}
}