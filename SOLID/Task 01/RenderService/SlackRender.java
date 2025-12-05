package RenderService;

import Notification.Notification;
public class SlackRender implements Render{
    @Override
    public String render(Notification notification) {
        return "[SLACK] Notification " + notification.getId();
    }
}
