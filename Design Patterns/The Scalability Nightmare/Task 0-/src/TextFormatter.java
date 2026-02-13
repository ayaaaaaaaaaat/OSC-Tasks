public class TextFormatter implements EmailFormatter{
    @Override
    public void format(String message, User user) {
        System.out.println( "[Email] Sending Text Format to: " + user.getEmail() + "\n" + message + "\n");
    }
}
