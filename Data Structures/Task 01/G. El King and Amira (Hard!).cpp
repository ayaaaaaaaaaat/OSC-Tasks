#include <bits/stdc++.h>
#define ll long long
#define el '\n'
using namespace std;
void testCase() {
    ll n ; cin >> n;
    ll square_root_el_n = sqrt(n);
    square_root_el_n*=square_root_el_n;
    cout << (square_root_el_n == n? "YES\n":"NO\n");
}
int main() {
    ios::sync_with_stdio(0); cin.tie(0); cout.tie(0);
    int t = 1; //cin >> t;
    while (t--)
        testCase();
}