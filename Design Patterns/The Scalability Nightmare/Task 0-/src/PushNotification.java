public class PushNotification implements Notification{
    @Override
    public void send(User user, String message) {
        if (user.hasMobileApp()) {
            System.out.println("[Push] To Device ID: " + user.getDeviceId());
        }
    }
}
