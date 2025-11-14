class Solution {
public:
    char kthCharacter(int k) {
        string s = "a";
        while(s.size() < k){
            string tmp = "";
            for(auto a : s){
                char x = a + 1;
                tmp += x ;
            }
            s+=tmp;
        }
        return s[k-1];
    }
};