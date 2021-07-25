package model;
import org.tartarus.martin.Stemmer;

public class CustomStemmer {

    String word;
    Stemmer stemmer;

    {
        stemmer = new Stemmer();
    }

    public CustomStemmer() {
        word = "";
    }

    public CustomStemmer(String word) {
        this.word = word;
        stem();
    }

    public CustomStemmer(char[] wordArray) {
        word = new String(wordArray);
        stem();
    }

    private void stem() {
        word = word.toLowerCase();
        stemmer.add(word.toCharArray(), word.length());
        stemmer.stem();
    }

    public String stemWord(String word) {
        this.word = word;
        stem();
        return stemmer.toString();
    } 

    public CustomStemmer setWord(String word) {
        this.word = word;
        stemmer = new Stemmer();
        stem();
        return this;
    }

    @Override
    public String toString() {
        return stemmer.toString();
    }
}