package rfidlocker.utils;

import java.util.HashMap;

import jakarta.servlet.http.HttpSession;
import lombok.Getter;

public class SessionUtil {
	@Getter
	static String sessionId;
	static HashMap sessionMap;

	
	public static void setSessionId (HttpSession session) {
		sessionId = session.getId();
	}
	
	public static void setSessionMap (HttpSession session) {
		sessionMap = new HashMap();
		sessionMap.put(session.getId(), session);
	}
	
	public static HttpSession getSession () {
		try {
			return (HttpSession) sessionMap.get(sessionId);
		} catch (NullPointerException npe) {
			return null;
		}
	}
}