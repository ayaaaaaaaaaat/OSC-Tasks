public class HtmlFormatter implements EmailFormatter{
    @Override
    public void format(String message, User user) {
        System.out.println("[Email] Sending HTML Format to: " + user.getEmail() + "\n"+ message+"\n");
    }
}
