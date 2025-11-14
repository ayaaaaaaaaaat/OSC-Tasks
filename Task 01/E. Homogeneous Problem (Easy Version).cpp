#include <bits/stdc++.h>
#define ll long long
#define el '\n'
using namespace std;
void testCase() {
    ll x, y; cin >> x >> y;
	if (x > y) swap(x,y);
	x--;
	ll r1 = (y * (y + 1) / 2) - (x * (x + 1) / 2);
	cout << r1 << el;
	x/=2;y/=2;
	ll r2 = (y * (y + 1)) - (x * (x + 1));
	cout << r2 << el;
	cout << r1 - r2 << el;
}
int main() {
    ios::sync_with_stdio(0); cin.tie(0); cout.tie(0);
    int t = 1; //cin >> t;
    while (t--)
        testCase();
}