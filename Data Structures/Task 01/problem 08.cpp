class Solution {
public:
    string decodeString(string s) {
        int idx1 = -1 , idx2 = -1 , num = 0;
    for (int i = 0 ; i < s.size() ;++i)
        if (s[i] == '[') idx1 = i;
    if(idx1 == -1) return s;
    idx2 = idx1 + 1;
    while (idx2 < s.size() && s[idx2] != ']') idx2++;
    string tmp = s.substr(idx1+1, idx2 - idx1 - 1);
    int curr_num_idx = idx1 - 1 , x = 1;
    while (curr_num_idx >= 0 && isdigit(s[curr_num_idx])) {
        num = num + (s[curr_num_idx] - '0') * x;
        curr_num_idx--;
        x *= 10;
    }
    string first_part = s.substr(0, curr_num_idx + 1);
    string last_part = "";
    idx2++;
    if (idx2 < s.size())
        last_part = s.substr(idx2);
    string middle_part = "";
    for (int i = 0; i < num; i++)
        middle_part += tmp;
    return decodeString(first_part+middle_part+last_part);
    }
};