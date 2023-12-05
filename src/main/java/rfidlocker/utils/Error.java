package rfidlocker.utils;

public class Error {

	// 自定义ForbiddenException
	static class ForbiddenException extends RuntimeException {
		public ForbiddenException(String message) {
			super(message);
		}

	}
}
