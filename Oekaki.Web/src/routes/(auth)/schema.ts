import { z } from 'zod';

export const registerSchema = z
	.object({
		username: z
			.string({ required_error: 'Insert an username' })
			.min(2, {
				message: 'Your username needs to be at least 2 characters-long'
			})
			.max(20, {
				message: 'Your username cannot be longer than 20 characters'
			}),
		email: z
			.string({ required_error: 'Insert an email address' })
			.email({ message: 'Not a valid email address' }),
		password: z
			.string({ required_error: 'Insert a password' })
			.min(8, { message: 'The password needs at least 8 characters' }),
		passwordConfirm: z.string({ required_error: 'Confirm your password' })
	})
	.superRefine(({ password, passwordConfirm }, context) => {
		if (password !== passwordConfirm) {
			context.addIssue({
				code: z.ZodIssueCode.custom,
				message: 'Your passwords do not match',
				path: ['password']
			});
			context.addIssue({
				code: z.ZodIssueCode.custom,
				message: 'Your passwords do not match',
				path: ['passwordConfirm']
			});
		}
	});

export const loginSchema = z.object({
	email: z
		.string({ required_error: 'Insert an email address' })
		.email({ message: 'Not a valid email address' }),
	password: z
		.string({ required_error: 'Insert your password' })
		.min(8, { message: 'Passwords needs at least 8 characters' })
});

export type RegisterSchema = typeof registerSchema;
export type LoginSchema = typeof loginSchema;
