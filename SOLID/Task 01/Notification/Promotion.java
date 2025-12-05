package Notification;

import java.time.LocalDate;

public class Promotion extends Notification{
    private LocalDate expiryDate;      // Only for PROMOTION

    public Promotion(String id, String userId, String target, String preferredChannel, LocalDate expiryDate) {
        super(id, userId, target, preferredChannel);
        this.expiryDate = expiryDate;
    }
    public boolean has_expiryDate(){return expiryDate != null;}
    public void validate(){
        if(!has_expiryDate()){throw new IllegalArgumentException("Promotions require expiry date");}
    }
    public LocalDate getExpiryDate() { return expiryDate; }

}
