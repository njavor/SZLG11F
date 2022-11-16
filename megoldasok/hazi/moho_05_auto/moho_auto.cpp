#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

bool sortbysec(const pair<int, int>& a,
    const pair<int, int>& b)
{
    return (a.second > b.second);
}

int main()
{
    int K, N, B, L;
    cin >> K >> N >> B >> L;

    vector<pair<int, int>> theList(N);

#pragma region readIn
    for (auto& par : theList)
        cin >> par.first >> par.second;
#pragma endregion


    int stops = 0;

    int range;
    int travelled = 0;

    int i = 0;
    int j = 0;
    vector<pair<int, int>> inRange;
    while (travelled < K)
    {
        range = (B / L) * 100;
        if (K <= travelled + range)
            travelled = K;
        else
        {
            while (i < N && theList[i].first <= range + travelled) {
                i++;
                inRange.push_back(theList[i-1]);
            }

            sort(inRange.begin(), inRange.end(), sortbysec);

            B -= ((inRange[0].first - travelled) / 100 * L);
            B += inRange[0].second;

            travelled += inRange[0].first - travelled;
            stops++;

            while (j < N && theList[j] != inRange[0])
                j++;

            i = j;
            inRange.clear();
            j = 0;
        }
    }

    cout << stops;
}