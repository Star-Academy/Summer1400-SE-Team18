package model;

import java.util.ArrayList;
import java.util.HashSet;

import java.util.Iterator;

public class AnswersWrapper {
    private HashSet<String> noTagAnswers;
    private HashSet<String> plusTagAnswers = new HashSet<String>();
    private HashSet<String> minusTagAnswers = new HashSet<String>();

    public AnswersWrapper(SearchCommandWrapper searchCommandWrapper) {
        noTagAnswers = chooseAnswerFromNoTags(searchCommandWrapper.getNoTags());
        for (HashSet<String> plusTag : searchCommandWrapper.getPlusTags()) 
            plusTagAnswers.addAll(plusTag);
        for (HashSet<String> minusTag : searchCommandWrapper.getMinusTags()) 
            minusTagAnswers.addAll(minusTag);
    }

    public HashSet<String> chooseAnswerFromNoTags(ArrayList<HashSet<String>> noTags) {
        if (noTags.size() == 0) return new HashSet<String>();
        HashSet<String> ret = noTags.get(0);
        Iterator<String> iterator = ret.iterator();
        while(iterator.hasNext()) {
            String string = iterator.next();
            for (HashSet<String> noTag : noTags) 
                if (!noTag.contains(string)) {
                    iterator.remove(); 
                    break;
                }
        }
        return ret;
    }

    public HashSet<String> getNoTagAnswers() {
        return noTagAnswers;
    }

    public HashSet<String> getPlusTagAnswers() {
        return plusTagAnswers;
    }

    public HashSet<String> getMinusTagAnswers() {
        return minusTagAnswers;
    }
}