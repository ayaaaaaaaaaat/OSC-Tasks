////By ChatGPT
//package Testing;
//
//import Notification.*;
//import SendingService.*;
//import RenderService.*;
//import Users.*;
//
//import java.time.LocalDate;
//
//public class Main {
//    public static void main(String[] args) {
//
//        // 1. Initialize User Repository
//        UserRepository userRepository = new UserInfo();
//
//        // 2. Initialize Senders
//        sendingService emailSender = new EmailSender();
//        sendingService slackSender = new SlackSender();
//
//        // 3. Initialize Renderers
//        Render emailRender = new EmailRender();
//        Render slackRender = new SlackRender();
//
//        // 4. Create NotificationManager for Email and Slack
//        NotificationManager emailManager = new NotificationManager(userRepository, emailSender, emailRender);
//        NotificationManager slackManager = new NotificationManager(userRepository, slackSender, slackRender);
//
//        // 5. Create Notifications
//        Notification alert1 = new Alert("alert1", "user1", "teamA", 1, null, "EMAIL");
//        Notification promotion1 = new Promotion("promo1", "user3", "teamB", "SLACK", LocalDate.now().plusDays(5));
//
//        // 6. Process Notifications
//        System.out.println("---- Sending Alert ----");
//        emailManager.process(alert1);
//
//        System.out.println("\n---- Sending Promotion ----");
//        slackManager.process(promotion1);
//
//        // 7. Test GDPR filter (user in EU)
//        Notification promotionEU = new Promotion("promoEU", "user2", "teamC", "EMAIL", LocalDate.now().plusDays(3));
//        System.out.println("\n---- Sending Promotion to EU user ----");
//        emailManager.process(promotionEU);
//    }
//}
