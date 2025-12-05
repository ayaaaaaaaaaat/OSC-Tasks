class Solution {
public:
    int countStudents(vector<int>& students, vector<int>& sandwiches) {
        queue<int> q;
        int cnt1 = 0,cnt0 = 0;
        for (auto i : students)
            if(i) cnt1++;
        cnt0 = students.size() - cnt1;    
        for(auto i : sandwiches){
            if(i){
                if(!cnt1) break;
                cnt1--;
            }
            else{
                if(!cnt0) break;
                cnt0--;
            }
        }
        return cnt0 + cnt1 ;
    }
};