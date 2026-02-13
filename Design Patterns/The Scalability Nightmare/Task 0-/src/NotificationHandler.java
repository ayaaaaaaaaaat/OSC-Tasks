import java.util.ArrayList;
import java.util.List;

public class NotificationHandler {
    private List<Notification> NotificationsList;

    public NotificationHandler() {
        NotificationsList = new ArrayList<>();
    }

    public void addNotification(Notification notification) {
        NotificationsList.add(notification);
    }

    public List<Notification> getNotificationsList() {
        return NotificationsList;
    }

    public void sendAllNotifications(User user, String message) {
        for (Notification notification : NotificationsList)
            notification.send(user, message);
    }
}
