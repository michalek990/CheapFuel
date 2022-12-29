package com.example.fuel.ui.fragment.user

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.Menu
import android.view.MenuInflater
import android.view.View
import android.view.ViewGroup
import android.widget.PopupMenu
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.core.content.ContextCompat
import androidx.core.widget.NestedScrollView
import androidx.lifecycle.ViewModelProvider
import com.example.fuel.R
import com.example.fuel.databinding.FragmentUserDetailsBinding
import com.example.fuel.enums.AccountStatus
import com.example.fuel.enums.Role
import com.example.fuel.mock.Auth
import com.example.fuel.viewmodel.UserDetailsViewModel
import com.example.fuel.viewmodel.ViewModelFactory

class UserDetailsFragment : Fragment(R.layout.fragment_user_details) {
    private lateinit var viewModel: UserDetailsViewModel
    private lateinit var binding: FragmentUserDetailsBinding
    private var username: String? = null

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        viewModel = ViewModelProvider(requireActivity(), ViewModelFactory())[UserDetailsViewModel::class.java]
        binding = FragmentUserDetailsBinding.inflate(inflater, container, false)

        username = requireArguments().getString("username")

        setAppBarTitle()
        loadUserData()
        initBannedObserver()
        initReviewSection()
        initReviewObserver()
        initDeleteReviewObserver()
        initPopupMenu()

        return binding.root
    }

    private fun loadUserData() {
        viewModel.getUser(username!!)
        viewModel.user.observe(viewLifecycleOwner) {
            initWithData()
            showLayout()
        }
    }

    private fun initWithData() {
        binding.tvUsername.text = viewModel.getUsername()
        binding.tvAccountCreatedAt.text = viewModel.getCreatedAt()
        binding.tvUserEmail.text = viewModel.getEmail()
        binding.tvEmailAddressConfirmed.text = if (viewModel.isEmailConfirmed()) getString(R.string.yes)
                                               else getString(R.string.no)
        binding.tvUserRole.text = viewModel.getRole().value
        setAccountStatus()
    }

    private fun setAccountStatus() {
        val status = viewModel.getAccountStatus()
        val color = when (status) {
            AccountStatus.NEW -> ContextCompat.getColor(requireContext(), R.color.light_blue)
            AccountStatus.ACTIVE -> ContextCompat.getColor(requireContext(), R.color.green)
            AccountStatus.BANNED -> ContextCompat.getColor(requireContext(), R.color.red)
        }

        binding.tvAccountStatus.text = status.value
        binding.tvAccountStatus.setTextColor(color)
    }

    private fun setAppBarTitle() {
        (activity as AppCompatActivity).supportActionBar?.title = username!!
    }

    private fun initBannedObserver() {
        // TODO: Implement after issue #174
    }

    private fun initReviewSection() {
        loadReviews()

        binding.nsvUserDetailsContainer
            .setOnScrollChangeListener { v, _, scrollY, _, oldScrollY ->
                val nsv = v as NestedScrollView

                if (oldScrollY < scrollY
                    && scrollY == (nsv.getChildAt(0).measuredHeight - nsv.measuredHeight)
                    && viewModel.hasMoreReviews()) {

                    loadReviews()
                }
            }
    }

    private fun loadReviews() {
        viewModel.getNextPageOfUserReviews(username!!)
    }

    private fun initReviewObserver() {
        viewModel.reviews.observe(viewLifecycleOwner) { response ->
            val fragmentManager = childFragmentManager
            val fragmentTransaction = fragmentManager.beginTransaction()
            val parent = binding.llcReviewsContainer

            val page = response.body()

            for (review in page?.data!!) {
                if (review.username == Auth.username) continue

                val reviewFragment = UserReviewFragment(review)
                fragmentTransaction.add(parent.id, reviewFragment)
            }
            fragmentTransaction.commitNow()

            if (!viewModel.hasMoreReviews()) hideReviewSectionProgressBar()
        }
    }

    private fun initDeleteReviewObserver() {
        viewModel.deleteReview.observe(viewLifecycleOwner) { response ->
            if (response.isSuccessful) {
                refreshReviews()
                showReviewSectionProgressBar()
            }

            val text = if (response.isSuccessful) resources.getString(R.string.deleted)
            else resources.getString(R.string.an_error_occurred)
            val toast = Toast.makeText(requireContext(), text, Toast.LENGTH_SHORT)
            toast.show()
        }
    }

    private fun refreshReviews() {
        val parent = binding.llcReviewsContainer
        parent.removeAllViews()

        viewModel.getFirstPageOfReviews(username!!)
    }

    private fun showReviewSectionProgressBar() {
        binding.pbReviewsLoad.visibility = View.VISIBLE
    }

    private fun hideReviewSectionProgressBar() {
        binding.pbReviewsLoad.visibility = View.GONE
    }

    private fun showLayout() {
        binding.pbUserDetailsLoad.visibility = View.GONE
        binding.nsvUserDetailsContainer.visibility = View.VISIBLE
    }

    fun initPopupMenu() {
        val actionButton = binding.acibUserActionButton

        if (Auth.role != Role.ADMIN) {
            actionButton.visibility = View.GONE
            return
        }

        actionButton.setOnClickListener {
            val popupMenu = PopupMenu(requireActivity(), actionButton)
            initPopupMenuItems(popupMenu)

            popupMenu.show()
        }
    }

    private fun initPopupMenuItems(popupMenu: PopupMenu) {
        val banItem = popupMenu.menu.add(Menu.NONE, Menu.NONE, 1, resources.getString(R.string.ban_user))

        banItem.setOnMenuItemClickListener {
            openBanView()
            true
        }
    }

    private fun openBanView() {

    }

    override fun onDestroyView() {
        super.onDestroyView()

        viewModel.clear()
    }
}