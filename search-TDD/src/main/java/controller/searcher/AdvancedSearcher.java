package controller.searcher;

import controller.DatabaseController;
import controller.ProgramController;
import controller.SetProcessor;
import controller.TagFilter;
import controller.WordController;
import model.AnswerTags;
import model.Data;
import model.TagsInterface;

import java.util.HashSet;
import java.util.Iterator;
import java.util.Set;

public class AdvancedSearcher implements Searcher {

    @Override
    public HashSet<String> search(String command) {
        ProgramController controllerInstance = ProgramController.getInstance();
        TagFilter tagFilter = controllerInstance.getTagFilter();
        TagsInterface filteredTags = tagFilter.parse(command);
        TagsInterface answerTags = getAnswerForEachTag(filteredTags);
        return getFinalAnswer(answerTags);
    }

    private HashSet<String> getFinalAnswer(TagsInterface answerTags) {
        ProgramController controllerInstance = ProgramController.getInstance();
        SetProcessor setProcessor = controllerInstance.getSetProcessor();
        HashSet<String> resultsForPlusTags = answerTags.getPlusTags();
        answerTags.addToNoTags(resultsForPlusTags);
        HashSet<String> resultsForMinusTags = answerTags.getMinusTags();
        HashSet<String> results = answerTags.getNoTags();
        setProcessor.removeAll(results, resultsForMinusTags);
        return results;
    }

    private TagsInterface getAnswerForEachTag(TagsInterface filteredTags) {
        AnswerTags answerTags = new AnswerTags();
        fillNoTagsAnswers(answerTags, filteredTags);
        fillPlusTagsAnswers(answerTags, filteredTags);
        fillMinusTagsAnswers(answerTags, filteredTags);
        return answerTags;
    }

    private void fillNoTagsAnswers(TagsInterface answerTags, TagsInterface filteredTags) {
        ProgramController controllerInstance = ProgramController.getInstance();
        WordController wordController = controllerInstance.getWordController();
        SetProcessor setProcessor = controllerInstance.getSetProcessor();
        if (filteredTags.getNoTags().size() == 0) return;
        Iterator<String> iterator = filteredTags.getNoTags().iterator();
        String stemmed = wordController.getStem(iterator.next());
        answerTags.addToNoTags(getFileNamesForWord(stemmed));
        while (iterator.hasNext()) {
            stemmed = wordController.getStem(iterator.next());
            Set initialSet = answerTags.getNoTags(), secondSet = getFileNamesForWord(stemmed);
            setProcessor.retainAll(initialSet, secondSet);
        }
    }

    private void fillPlusTagsAnswers(TagsInterface answerTags, TagsInterface filteredTags) {
        fillPlusOrMinusAnswers(answerTags.getPlusTags(), filteredTags.getPlusTags());
    }

    private void fillMinusTagsAnswers(TagsInterface answerTags, TagsInterface filteredTags) {
        fillPlusOrMinusAnswers(answerTags.getMinusTags(), filteredTags.getMinusTags());
    }

    private void fillPlusOrMinusAnswers(HashSet<String> answers, HashSet<String> taggedWords) {
        ProgramController controllerInstance = ProgramController.getInstance();
        WordController wordController = controllerInstance.getWordController();
        SetProcessor setProcessor = controllerInstance.getSetProcessor();
        for (String taggedWord : taggedWords) {
            String stemmed = wordController.getStem(taggedWord);
            Set initialSet = answers, secondSet = getFileNamesForWord(stemmed);
            setProcessor.addAll(initialSet, secondSet);
        }
    }

    private Data getDataForWord(String word) {
        ProgramController controllerInstance = ProgramController.getInstance();
        DatabaseController databaseController = controllerInstance.getDatabaseController();
        return databaseController.getDataForWord(word);
    }
    
    private HashSet<String> getFileNamesForWord(String word) {
        return getDataForWord(word).getFileNames();
    }
}