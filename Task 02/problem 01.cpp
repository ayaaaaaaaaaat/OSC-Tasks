class Solution {
public:
    bool backspaceCompare(string s, string t) {
        stack<char> st1 , st2;
        for(auto a : s){
        if( a == '#'){
            if(!st1.empty()) st1.pop();
        }
        else st1.push(a);
    }
    for(auto a : t){
        if( a == '#'){
            if(!st2.empty()) st2.pop();
        }
        else st2.push(a);
    }
    while(!(st1.empty() || st2.empty())){
        if(st1.top() == st2.top())
            st1.pop(),st2.pop();
        else break;    
    }
    return (!(st1.empty() && st2.empty()) ? false:true);
    }
};