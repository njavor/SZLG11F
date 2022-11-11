#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
    int K, N, B, L;
    cin >> K >> N >> B >> L;

    vector<pair<int, int>> theList(N);

    for (auto& par : theList)
    {
        cin >> par.first >> par.second;
    }

    int stops = 0;

    int range;
    int travelled = 0;
    int i = 0;
    while (travelled < K)
    {
        range = (B / L) * 100;
        if (K <= travelled + range) { travelled = K; }
        else {
            while (i < N && theList[i].first <= range) { i++; }

            B -= ((theList[i - 1].first - travelled) / 100 * L);
            B += theList[i - 1].second;

            travelled += theList[i - 1].first - travelled;
            stops++;
        }
    }

    cout << stops;
}