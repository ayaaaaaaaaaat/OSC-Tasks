package Notification;

import java.time.LocalDate;

public class Alert extends Notification{

    private Integer priority;          // Only for ALERT

    public Alert(String id, String userId, String target,Integer priority, LocalDate expiryDate, String preferredChannel) {
        super(id, userId, target, preferredChannel);
        this.priority = priority;
    }
    public boolean has_priority_value(){return priority != null;}
    public void validate(){
        if(!has_priority_value()) {throw new IllegalArgumentException("Alerts require priority");}
    }
    public Integer getPriority() { return priority; }

}
