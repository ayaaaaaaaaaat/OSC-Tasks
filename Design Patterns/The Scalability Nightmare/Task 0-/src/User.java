public abstract class User {
    private String Email;
    private boolean hasMobileApp;
    private String DeviceId;

    public User(String Email){
        this.Email = Email;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        Email = email;
    }

    public boolean hasMobileApp() {
        return hasMobileApp;
    }

    public void setHasMobileApp(boolean hasMobileApp) {
        this.hasMobileApp = hasMobileApp;
    }

    public String getDeviceId() {
        return DeviceId;
    }

    public void setDeviceId(String deviceId) {
        DeviceId = deviceId;
    }

    public abstract EmailFormatter getEmailFormatter();
}
