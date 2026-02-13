public class ProUser extends User{
    public ProUser(String Email) {
        super(Email);
    }
    @Override
    public EmailFormatter getEmailFormatter() {
        return new HtmlFormatter();
    }
}
