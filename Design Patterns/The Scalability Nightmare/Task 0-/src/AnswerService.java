import java.util.ArrayList;
import java.util.List;
public class AnswerService {
    private NotificationHandler notificationHandler;

    public AnswerService(NotificationHandler notificationHandler) {
        this.notificationHandler = notificationHandler;
    }

        public void processAnswer(String answerText, User author, User questionAsker, String portalType) {
        // 1. Validation Logic
        if (portalType.equals("Kids") && answerText.contains("slang")) {
            System.out.println("Blocked: Kids mode detects slang.");
            return;
        }
        if (answerText.contains("bad_word")) {
            System.out.println("Blocked: Profanity detected.");
            return;
        }

        // 2. Save Logic
        System.out.println("[DB] Answer saved: " + answerText);

        notificationHandler.sendAllNotifications(questionAsker, answerText);
    }
}
