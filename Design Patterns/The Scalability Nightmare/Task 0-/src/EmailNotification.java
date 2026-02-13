public class EmailNotification implements Notification{
    @Override
    public void send(User user, String message) {
        // 3. Notification Logic
        EmailFormatter formatter = user.getEmailFormatter();
        formatter.format(message, user);
    }
}
