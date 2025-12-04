class Solution {
public:
    int countStudents(vector<int>& students, vector<int>& sandwiches) {
        queue<int> q;
        int cnt = 0 , idx = 0;
        for (int s : students)
            q.push(s);
        while (!q.empty() && idx < students.size()) {
            int x = q.front();
            q.pop();
            if (x == sandwiches[idx])
                cnt = 0,idx++;
            else {
                q.push(x);
                cnt++;
                if (cnt == q.size()) break;
            }
        }
        return q.size();
    }
};
