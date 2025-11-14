#include <bits/stdc++.h>
#define ll long long
#define el '\n'
using namespace std;
void testCase() {
    int n ; cin >> n;
    int tmp1 = -1 , tmp2 = -1;
    bool flg = 0;
    while(n--){
        cin >> tmp1;
        if(tmp2 != -1){
            if(abs(tmp2-tmp1)!= 7 && abs(tmp2-tmp1)!= 5) flg = 1; 
        }
        tmp2 = tmp1;
    }
    cout << (flg ? "NO\n" : "YES\n");
}
int main() {
    ios::sync_with_stdio(0); cin.tie(0); cout.tie(0);
    int t = 1; cin >> t;
    while (t--)
        testCase();
}