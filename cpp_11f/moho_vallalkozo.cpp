#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main() {
    int result = 0;

    int N, M;
    cin >> N >> M;
    vector<int> jobPerDay(N);
    vector<int> deadlines(M);

    for (auto& i : jobPerDay) { cin >> i; }
    for (auto& i : deadlines) { cin >> i; }

    sort(deadlines.begin(), deadlines.end(), [](int a, int b) {return a < b; });
    
    for (size_t i = 0; i < N; i++)
    {
        for (size_t d = 0; d < deadlines.size(); d++)
            if (deadlines[0]-1 < i)
                deadlines.erase(deadlines.begin());

        for (size_t j = 0;  j < jobPerDay[i];  j++)
            if (deadlines.size() != 0) {
                deadlines.erase(deadlines.begin());
                result++;
            }
    }


    cout << result;
}