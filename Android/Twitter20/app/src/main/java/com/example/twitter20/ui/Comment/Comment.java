package com.example.twitter20.ui.Comment;

public class Comment {
    public String Comment;
    public int CID;
    public int TID;

    public Comment(String comment) {
        this.Comment = comment;
    }

    public Comment() {

    }

    public int getCID() {
        return CID;
    }

    public void setCID(int CID) {
        this.CID = CID;
    }

    public int getTID() {
        return TID;
    }

    public void setTID(int TID) {
        this.TID = TID;
    }

    public String getComment() {
        return Comment;
    }


    public void setComment(String comment) {
        Comment = comment;
    }
}
