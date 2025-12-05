package Notification;

import java.time.LocalDate;

public abstract class Notification {
    private String id;
    private String userId;
    private String target;
    private String preferredChannel;   // EMAIL or SLACK

    public Notification(String id, String userId, String target, String preferredChannel) {
        this.id = id;
        this.userId = userId;
        this.target = target;
        this.preferredChannel = preferredChannel;
    }

    public String getId() { return id; }
    public String getUserId() { return userId; }
    public String getTarget() { return target; }
    public String getPreferredChannel() { return preferredChannel; }

    // Dummy rendering methods
    public abstract void validate();
    public String render() {
        return preferredChannel.equals("EMAIL") ? "[EMAIL] Notification " + id : "[SLACK] Notification " + id;
    }
}
