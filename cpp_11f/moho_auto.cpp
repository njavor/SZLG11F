#include <iostream>
#include <vector>
#include <algorithm>


using namespace std;

int main()
{
    int K, N, B, L;
    cin >> K >> N >> B >> L;

    vector<pair<int, int>> list(N);

    for (auto& i : list)
    {
        cin >> i.first >> i.second;
    }

    int travelled = 0;
    int maxBenzin = 0;
    int stops = 0;
    while (travelled <= K)
    {
        int range = (B / L) * 100;
        int i = 0;
        while (list[i].first <= range)
        {
            if (list[i].second > maxBenzin) {
                maxBenzin = list[i].second;
                travelled += list[i].first - travelled;
                B = B % L;
                stops++;
            }
            i++;
        }
        B += maxBenzin;
    }
    cout << stops;
}