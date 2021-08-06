package controller.searcher;

import controller.DatabaseController;
import controller.ProgramController;
import controller.TagFilter;
import controller.WordController;
import model.AnswerTags;
import model.Data;
import model.TagsInterface;

import java.util.HashSet;
import java.util.Iterator;

public class AdvancedSearcher implements Searcher {
    public final static String PLUS_SIGN = ProgramController.getPlusSign();
    public final static String MINUS_SIGN = ProgramController.getMinusSign();
    

    @Override
    public HashSet<String> search(String command) {
        TagFilter tagFilter = ProgramController.getTagFilter();
        TagsInterface filteredTags = tagFilter.parse(command);
        TagsInterface answerTags = getAnswerForEachTag(filteredTags);
        return getFinalAnswer(answerTags);
    }

    private HashSet<String> getFinalAnswer(TagsInterface answerTags) {
        answerTags.addToNoTags(answerTags.getPlusTags());
        answerTags.getNoTags().removeAll(answerTags.getMinusTags());
        return answerTags.getNoTags();
    }

    private TagsInterface getAnswerForEachTag(TagsInterface filteredTags) {
        AnswerTags answerTags = new AnswerTags();
        fillNoTagsAnswers(answerTags, filteredTags);
        fillPlusTagsAnswers(answerTags, filteredTags);
        fillMinusTagsAnswers(answerTags, filteredTags);
        return answerTags;
    }

    private void fillNoTagsAnswers(TagsInterface answerTags, TagsInterface filteredTags) {
        WordController wordController = ProgramController.getWordController();
        if (filteredTags.getNoTags().size() == 0) return;
        Iterator<String> iterator = filteredTags.getNoTags().iterator();
        String stemmed = wordController.getStem(iterator.next());
        answerTags.addToNoTags(getFileNamesForWord(stemmed));
        while (iterator.hasNext()) {
            stemmed = wordController.getStem(iterator.next());
            answerTags.getNoTags().retainAll(getFileNamesForWord(stemmed));
        }
    }

    private void fillPlusTagsAnswers(TagsInterface answerTags, TagsInterface filteredTags) {
        fillPlusOrMinusAnswers(answerTags.getPlusTags(), filteredTags.getPlusTags());
    }

    private void fillMinusTagsAnswers(TagsInterface answerTags, TagsInterface filteredTags) {
        fillPlusOrMinusAnswers(answerTags.getMinusTags(), filteredTags.getMinusTags());
    }

    private void fillPlusOrMinusAnswers(HashSet<String> answers, HashSet<String> taggedWords) {
        WordController wordController = ProgramController.getWordController();
        for (String taggedWord : taggedWords) {
            String stemmed = wordController.getStem(taggedWord);
            answers.addAll(getFileNamesForWord(stemmed));
        }
    }

    private Data getDataForWord(String word) {
        DatabaseController databaseController = ProgramController.getDatabaseController();
        return databaseController.getDataForWord(word);
    }
    
    private HashSet<String> getFileNamesForWord(String word) {
        return getDataForWord(word).getFileNames();
    }
}