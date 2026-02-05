package Users;

import java.util.HashMap;
import java.util.Map;

public class UserInfo implements UserRepository {

    private Map<String, String> locationsMap = new HashMap<>();

    public UserInfo() {
        String[] locations = {"US", "EU", "CA", "IN", "UK", "AU"};
        for (int i = 1; i <= 30; i++) {
            String userId = "user" + i;                    
            locationsMap.put(userId,locations[(i-1) % locations.length]);
        }
    }

    @Override
    public String getLocation(String userId) {
        return locationsMap.getOrDefault(userId, "Unknown");
    }
}
