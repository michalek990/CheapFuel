package com.example.fuel.ui.fragment.login

import android.os.Bundle
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.lifecycle.ViewModelProvider
import androidx.navigation.fragment.findNavController
import com.example.fuel.R
import com.example.fuel.databinding.FragmentEmailBinding
import com.example.fuel.databinding.FragmentLoginBinding
import com.example.fuel.utils.extension.ContextExtension.Companion.hideKeyboard
import com.example.fuel.utils.extension.EditTextExtension.Companion.afterTextChanged
import com.example.fuel.utils.validation.ValidatorEmail
import com.example.fuel.utils.validation.ValidatorPassword
import com.example.fuel.utils.validation.ValidatorUsername
import com.example.fuel.viewmodel.UserLoginViewModel
import com.example.fuel.viewmodel.UserRegistrationViewModel
import com.example.fuel.viewmodel.ViewModelFactory


class LoginFragment : Fragment(R.layout.fragment_login) {

    private var _binding: FragmentLoginBinding? = null
    private val binding get() = _binding!!
    private var errorUsername: ValidatorUsername.Error? = null
    private var errorPassword: ValidatorPassword.Error? = null
    private lateinit var viewModel: UserLoginViewModel

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentLoginBinding.inflate(inflater, container, false)
        viewModel = ViewModelProvider(requireActivity(), ViewModelFactory())[UserLoginViewModel::class.java]

        binding.clMain.setOnClickListener { view -> view.hideKeyboard() }
        binding.toolbar.setNavigationIcon(androidx.appcompat.R.drawable.abc_ic_ab_back_material)
        binding.toolbar.setOnClickListener { findNavController().popBackStack() }
        binding.btnNextPage.setOnClickListener(btnGoToNextPage)

        return binding.root
    }

    private val btnGoToNextPage = View.OnClickListener { view ->
        val username = binding.etUsername.text.toString()
        val password = binding.etPassword.text.toString()

        errorUsername = viewModel.getUsernameValidationError(username)
        errorPassword = viewModel.getPasswordValidationError(password)

        if (errorUsername == null && errorPassword == null) {
            viewModel.user.value?.username = username
            viewModel.user.value?.password = password
            viewModel.navigateToTBAFragment(view)
        } else if (errorUsername != null) {
            showUsernameError()
            setUsernameErrorTracking()
        } else if (errorPassword != null) {
            showPasswordError()
            setPasswordErrorTracking()
        }
    }

    override fun onDestroy() {
        super.onDestroy()
        _binding = null
    }

    private fun loginUser() {
        viewModel.postLogin(viewModel.user.value!!)
        viewModel.response.observe(viewLifecycleOwner) { response ->
            if (response.isSuccessful) {
                Log.d("XD", "User has been logged in")
            } else {
                Log.d("XD", response.code().toString())
            }
        }
    }

    private fun showUsernameError() {
        binding.tilUsername.setBackgroundResource(R.drawable.bg_rounded_error)
        binding.tvUsernameError.text = errorUsername.toString()
    }

    private fun hideUsernameError() {
        binding.tilUsername.setBackgroundResource(R.drawable.bg_rounded)
        binding.tvUsernameError.text = ""
    }

    private fun showPasswordError() {
        binding.tilPassword.setBackgroundResource(R.drawable.bg_rounded_error)
        binding.tvPasswordError.text = errorPassword.toString()
    }

    private fun hidePasswordError() {
        binding.tilPassword.setBackgroundResource(R.drawable.bg_rounded)
        binding.tvPasswordError.text = ""
    }

    private fun setUsernameErrorTracking() {
        binding.etUsername.afterTextChanged { username ->
            if (viewModel.getUsernameValidationError(username) == null) {
                hideUsernameError()
                stopUsernameErrorTracking()
            }
        }
    }

    private fun setPasswordErrorTracking() {
        binding.etPassword.afterTextChanged { password ->
            if (viewModel.getPasswordValidationError(password) == null) {
                hidePasswordError()
                stopPasswordErrorTracking()
            }
        }
    }

    private fun stopUsernameErrorTracking() {
        binding.etUsername.afterTextChanged {}
    }

    private fun stopPasswordErrorTracking() {
        binding.etPassword.afterTextChanged {}
    }
}