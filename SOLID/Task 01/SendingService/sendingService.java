package SendingService;
import Notification.Notification;
import RenderService.Render;

public interface sendingService {
    void send(String target, Notification notification, Render render);
}