/*
#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main() {
    int N;
    cin >> N;
    vector<pair<int, int>> theList(N);

    for (auto& i : theList)
        cin >> i.first >> i.second;

    sort(theList.begin(), theList.end(), [](pair<int, int> p1, pair<int, int> p2) {return p1.second < p2.second; });


    int departure = 0;
    int sum = 0;
    vector<int> photoTimes;
    for (auto& par : theList)
    {
        if (departure <= par.first)
        {
            sum++;
            photoTimes.push_back(par.second - 1);
            departure = par.second;
        }
    }

    cout << sum << endl;

    departure = 0;
    for (auto& hour : photoTimes)
        cout << hour << " ";
}
*/