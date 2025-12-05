package SendingService;

import Notification.Notification;
import RenderService.Render;

public class SlackSender implements sendingService {
    @Override
    public void send(String target, Notification notification, Render render) {
        System.out.println("Sending by Slack to " + target + " and its content is:");
        System.out.println(render.render(notification));
    }
}
