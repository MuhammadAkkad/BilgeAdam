package com.example.twitter20.data;

import android.widget.EditText;

import androidx.appcompat.app.AppCompatActivity;

import com.example.twitter20.R;
import com.example.twitter20.data.model.LoggedInUser;

import java.io.IOException;

/**
 * Class that handles authentication w/ login credentials and retrieves user information.
 */
public class LoginDataSource  extends AppCompatActivity {
    final EditText usernameTEXT = findViewById(R.id.username);
    final EditText passward = findViewById(R.id.password);

    public Result<LoggedInUser> login(String username, String password) {

        try {
            // TODO: handle loggedInUser authentication
            LoggedInUser fakeUser =
                    new LoggedInUser(
                            java.util.UUID.randomUUID().toString(),
                            usernameTEXT.getText().toString());
            return new Result.Success<>(fakeUser);
        } catch (Exception e) {
            return new Result.Error(new IOException("Error logging in", e));
        }
    }

    public void logout() {
        // TODO: revoke authentication
    }
}
