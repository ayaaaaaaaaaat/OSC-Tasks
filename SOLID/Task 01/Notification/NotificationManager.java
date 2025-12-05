package Notification;
import RenderService.Render;
import SendingService.sendingService;
import Users.UserRepository;

import java.io.Reader;

public class NotificationManager {

    private UserRepository userRepository;
    private sendingService sendingService;  // only one field
    private Render render;

    public NotificationManager(UserRepository userRepository, sendingService sendingService,Render render) {
        this.userRepository = userRepository;
        this.sendingService = sendingService;
        this.render = render;
    }

    public void process(Notification notification) {

        // 1. Validation spaghetti
        notification.validate();
        if (notification instanceof Promotion) {
            if (userRepository.getLocation(notification.getUserId()).equals("EU")) {
                System.out.println("Filtered promotion for EU user: " + notification.getId());
                return;
            }
        }

        // 2. Delivery logic mixed with core logic
        sendingService.send(notification.getTarget(),notification,render);

    }
}
