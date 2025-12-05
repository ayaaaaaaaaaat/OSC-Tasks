package RenderService;

import Notification.Notification;
public class EmailRender implements Render {
    @Override
    public String render(Notification notification) {
        return "[EMAIL] Notification " + notification.getId();
    }
}

