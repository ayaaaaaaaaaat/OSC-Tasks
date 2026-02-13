public class FreeUser extends User {
    public FreeUser(String email) {
        super(email);
    }
        @Override
    public EmailFormatter getEmailFormatter() {
        return new TextFormatter();
    }
}
