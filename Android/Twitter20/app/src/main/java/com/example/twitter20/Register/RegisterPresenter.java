package com.example.twitter20.Register;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

import com.example.twitter20.DB.DbContract;
import com.example.twitter20.DB.DbHelper;

public class RegisterPresenter {
    DbHelper dbHelper;
    SQLiteDatabase dbWrite;
    SQLiteDatabase dbRead;
    Context context;

    RegisterPresenter(Context context) {
        this.context = context;
    }


    public boolean isUserExists(String TableName,
                                String dbfield, String fieldValue) {
        dbHelper = new DbHelper(context);
        dbWrite = dbHelper.getWritableDatabase();
        dbRead = dbHelper.getReadableDatabase();
        Cursor cursor = dbRead.rawQuery("select * from " + TableName + " where " + dbfield + " = ?",
                new String[]{fieldValue});
        if (cursor.getCount() <= 0) {
            cursor.close();
            return true;
        }
        cursor.close();
        return false;
    }


    public void InsertValues(String mName, String mNickName, String mAccount, String mPassword) {
        ContentValues values = new ContentValues();
        values.put(DbContract.UserEntry.COLUMN_NAME, mName);
        values.put(DbContract.UserEntry.COLUMN_NICKNAME, mNickName);
        values.put(DbContract.UserEntry.COLUMN_ACCOUNT, mAccount);
        values.put(DbContract.UserEntry.COLUMN_PASSWORD, mPassword);
        dbWrite.insert(DbContract.UserEntry.TABLE_NAME, null, values);

    }
}
