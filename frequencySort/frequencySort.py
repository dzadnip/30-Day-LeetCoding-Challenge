from collections import Counter
from collections import defaultdict

class Solution:
    def frequencySort(self, s: str) -> str:
        charCount = Counter(s)
        answer = ''
        for char, count in charCount.most_common():
            answer += char * count
        return answer

    def frequencySort2(self, s: str) -> str:
        if len(s) in [0,1,2]:
            return s
        mydict = defaultdict(int)
        for c in s:
            mydict[c] += 1
        sorted_by_vals = sorted(mydict.items(), key=lambda x: x[1], reverse=True)
        mystr= ""
        for s,c in sorted_by_vals:
            mystr += s*c
        return mystr

    # Runtime Distribution
    def frequencySort3(self, s: str) -> str:
        myDict = {}
        result = ""
        for val in s:
            if val in myDict:
                myDict[val] +=1
            else:
                myDict[val] = 1
        sortDict = sorted(myDict, key = lambda x: myDict[x], reverse = True)
        for char in sortDict:
            result += char * myDict[char]
        return result

    def frequencySort4(self, s: str) -> str:
        c = Counter(s)
        return "".join([c*rep for c,rep in c.most_common()])

    # Memory Distribution
    def frequencySort5(self, s: str) -> str:
        cntr = Counter(s).most_common()
        res=[]
        for x in cntr:
            res.append(x[0]*x[1])
        return ''.join(res)

ob = Solution()
print(ob.frequencySort("tree"))
print(ob.frequencySort2("cccaaa"))
print(ob.frequencySort3("Aabb"))
print(ob.frequencySort4("asdfds"))
print(ob.frequencySort5("asdfsdfds"))