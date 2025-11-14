#include <bits/stdc++.h>
#define ll long long
#define el '\n'
using namespace std;
int solve(ll n){
	if(n == 1) return 1;
	n = (n%2 ? 3*n+1:n/2);
	return solve(n) + 1;
}
void testCase() {
    int n ; cin >> n;
    cout << solve((ll)n) << el;
}
int main() {
    ios::sync_with_stdio(0); cin.tie(0); cout.tie(0);
    int t = 1; //cin >> t;
    while (t--)
        testCase();
}