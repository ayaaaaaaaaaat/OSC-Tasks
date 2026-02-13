//This code is written by ChatGPT
public class Main {
    public static void main(String[] args) {
        // Setup notification handler
        NotificationHandler handler = new NotificationHandler();
        handler.addNotification(new EmailNotification());
        handler.addNotification(new PushNotification());

        // Create service
        AnswerService answerService = new AnswerService(handler);

        // Create users
        ProUser alice = new ProUser("alice@example.com");
        alice.setHasMobileApp(true);
        alice.setDeviceId("device123");

        FreeUser bob = new FreeUser("bob@example.com");
        bob.setHasMobileApp(false);

        FreeUser charlie = new FreeUser("charlie@example.com");
        charlie.setHasMobileApp(true);
        charlie.setDeviceId("device456");

        // Create a dummy author (since we don't need one for req 1&2)
        User dummyAuthor = new FreeUser("author@example.com");  // Just a placeholder

        // Test 1: Pro User
        System.out.println("\n=== TEST 1: Pro User (HTML Email + Push) ===");
        answerService.processAnswer("Hello Pro!", dummyAuthor, alice, "Standard");

        // Test 2: Free User (no mobile)
        System.out.println("\n=== TEST 2: Free User (Text Email only) ===");
        answerService.processAnswer("Hello Free!", dummyAuthor, bob, "Standard");

        // Test 3: Free User with mobile
        System.out.println("\n=== TEST 3: Free User with Mobile (Text Email + Push) ===");
        answerService.processAnswer("Hello Mobile Free!", dummyAuthor, charlie, "Standard");
    }
}